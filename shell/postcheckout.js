#!/usr/bin/env node

const shell = require('../node_modules/shelljs');
const request  = require('../node_modules/request');
const red = "\033[31m";
const green = "\033[32m";
const black = "\033[30m";
const yellow = "\033[33m"
const colorReset = "\033[0m";

let commit = shell.exec('git rev-parse --verify HEAD', {silent:true});

if (commit.code !== 0) {
  shell.echo('Error: Get git commit failed');
  shell.exit(1);
}

commit = commit.stdout;

const url = 'https://api.github.com/repos/carlosharaujo/goldkeeper/commits/' + commit + '/check-runs';
let stateMarker;
let color;

request.get({
    url: url,
    headers: {
      'Accept': 'application/vnd.github.antiope-preview+json',
      'User-Agent': 'request'
    }
  }, (err, res, data) => {
    data = JSON.parse(data);
    if (err) {
      console.log('Error:', err);
    } else if (res.statusCode === 422) {
      console.log(data.message);
    } else if (res.statusCode !== 200) {
      console.log('Status:', res.statusCode);
    } else {
      try {
        const statuses = data;
        if(statuses && statuses.length > 0) {
          for (var i = 0; i < statuses.length; i++) {
            let status = statuses[i];
            switch (status.state) {
              case "success":
                stateMarker = "✔︎";
                color = green;
                break;
              case "failure", "error", "action_required", "cancelled", "timed_out":
                stateMarker = "✖︎"
                color = red;
              case "neutral":
                stateMarker = "◦"
                color = black;
              case "pending":
                stateMarker = "●"
                color = yellow;
            }
                
            stateMarker = color + stateMarker + colorReset;
            console.log(stateMarker + '    ' + status.context + '    ' + status.target_url);
          }
        }
        else {
            console.log('No status for ' + commit);
        }
      }
      catch {
          console.log('Error while parsing JSON response.');
      }
    }
});
