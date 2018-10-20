if git-branch-is -q -i -r "^feature/|^bugfix/|^hotfix/|^release/|^develop|^master"
then npm run lint:front && npm run build && npm run test ;
else echo 'Current branch is not included on gitflow. Skipping pre-push hook...' ; fi