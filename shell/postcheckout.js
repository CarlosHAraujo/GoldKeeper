#!/usr/bin/env node

const shell = require('../node_modules/shelljs');
const request  = require('../node_modules/request');
const red = "\033[31m";
const green = "\033[32m";
const black = "\033[30m";
const yellow = "\033[33m"
const colorReset = "\033[0m";

const branch = shell.exec('git rev-parse --abbrev-ref HEAD', {silent:true});

if (branch.code !== 0) {
  shell.echo('Error: Git commit failed');
  shell.exit(1);
}

const url = 'https://api.github.com/repos/carlosharaujo/goldkeeper/statuses/' + branch;
let stateMarker;
let color;

request.get({
    url: url,
    headers: {
      'User-Agent': 'request'
    }
  }, (err, res, data) => {
    if (err) {
      console.log('Error:', err);
    } else if (res.statusCode !== 200) {
      console.log('Status:', res.statusCode);
    } else {
      try {
        const statuses = JSON.parse(data);
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
            console.log('No status for ' + branch);
        }
      }
      catch {
          console.log('Error while parsing JSON response.');
      }
    }
});
