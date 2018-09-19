# Inserts github status on commit using github API

STATUS='pending'
case $AGENT_JOBSTATUS in
'Canceled')
    $STATUS='error'
    ;;
'Failed')
    $STATUS='failure'
    ;;
'Succeeded' | 'SucceededWithIssues')
    $STATUS='success'
    ;;
esac

TARGET_URL=https://dev.azure.com/carlosharaujo/goldkeeper/_build/results?buildId=$BUILD_BUILDID

curl --request POST --data '{"state": "$STATUS", "target_url": "$TARGET_URL", "context": "$BUILD_DEFINITIONNAME"}' https://api.github.com/repos/carlosharaujo/goldkeeper/statuses/$BUILD_SOURCEVERSION > /dev/null
