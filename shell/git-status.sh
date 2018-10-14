# Inserts github status on commit using github API

# FUNCTIONS
generate_post_data()
{
    cat <<EOF
    {
        "state": "$STATUS",
        "target_url": "$TARGET_URL",
        "context": "GoldKeeper-CI"
    }
EOF
}

# SCRIPT
STATUS='pending'
case $AGENT_JOBSTATUS in
'Canceled')
    STATUS='error'
    ;;
'Failed')
    STATUS='failure'
    ;;
'Succeeded' | 'SucceededWithIssues')
    STATUS='success'
    ;;
esac

TARGET_URL=https://dev.azure.com/carlosharaujo/goldkeeper/_build/results?buildId=$BUILD_BUILDID

# $1 is the first parameter and should be the github access token
curl --request POST -H "Authorization: token $1" --data "$(generate_post_data)" https://api.github.com/repos/carlosharaujo/goldkeeper/statuses/$BUILD_SOURCEVERSION > /dev/null
