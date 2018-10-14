# Inserts github status on commit using github API

# FUNCTIONS
generate_post_data()
{
    cat <<EOF
    {
        "state": "$STATUS",
        "target_url": "$TARGET_URL",
        "context": "$BUILD_DEFINITIONNAME"
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
echo $0
echo $1
echo $2
echo $3
echo $4
echo $5
curl --request POST -H "Authorization: token $1" --data "$(generate_post_data)" https://api.github.com/repos/carlosharaujo/goldkeeper/statuses/$BUILD_SOURCEVERSION > /dev/null
