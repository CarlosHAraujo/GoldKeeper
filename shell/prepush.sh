if git-branch-is -q -i -r "^feature/|^hotfix/|^bugfix/|^develop"
then npm run lint-front && npm run build && npm run test ; else echo 'Current branch is not "develop". Skipping pre-push hook...' ; fi