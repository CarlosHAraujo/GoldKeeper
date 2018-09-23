#!/usr/bin/env node

const shell = require('../GoldKeeper/ClientApp/node_modules/shelljs');
const request  = require('../GoldKeeper/ClientApp/node_modules/request');
const red = "\033[31m";
const green = "\x1b[32m";

const branch = shell.exec('git rev-parse --abbrev-ref HEAD');

if (branch.code !== 0) {
  shell.echo('Error: Git commit failed');
  shell.exit(1);
}

const url = 'https://api.github.com/repos/carlosharaujo/goldkeeper/statuses/' + branch;
const context = 'GoldKeeper-CI';
let state;

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
        const status = JSON.parse(data);

        if(status) {
          const contextStatus = status.filter(function(value) { return value.context === context; });
  
          if(contextStatus && contextStatus.length > 0) {
              const lastContext = contextStatus[0];
              state = lastContext.state;
          }
        } else {
            console.log('No status for ' + branch);
        }
      } catch {
          console.log('Error while parsing JSON response.');
      }
    }

    console.log("Last CI build: " + (state == "success" ? green : red) + state);
});