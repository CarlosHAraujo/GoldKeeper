#!/bin/bash

if [ -z "$SKIP_HOOKS" ]
then
    export SKIP_HOOKS=1
    npm run set-version 2>/dev/null || {
        echo "Skiping versioning..."
        exit 0
    }    
    git commit package.json package-lock.json --amend --no-verify --no-edit
else
    unset SKIP_HOOKS
fi
