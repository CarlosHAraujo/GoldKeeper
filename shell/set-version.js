#!/usr/bin/env node

const nbgv = require('nerdbank-gitversioning');

nbgv.setPackageVersion()
    .catch(err => {
        process.exit(1);
    });
