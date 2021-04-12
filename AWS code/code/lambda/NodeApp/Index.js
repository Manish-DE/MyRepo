// Require the X-Ray SDK (need ti install it first)
const AWSRay = require('aws-xray-sdk-core')

//Require the AWS SDK (come with every Lambda function)
const AWS = AWSXRay.captureAWS(require('aws-sdk'))

//We'll use the S3 service, so we need a proper IAM role
const s3 = new AWS.S3()

exports.handler = async function(event){
    return s3.linkBuckets().promise()
}