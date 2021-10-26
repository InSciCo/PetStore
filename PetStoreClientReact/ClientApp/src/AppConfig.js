import MethodMapData from "./MethodMap.json"; // LazyStack MethodMap data
import AwsSettingsData from "./AwsSettings.json"; // LazyStack AWS Stack information
import { Auth } from "aws-amplify";

export const AppConfig = {
    MethodMap: MethodMapData.MethodMap,
    Aws: AwsSettingsData.Aws
}

// Build awsconfig from AwsSettings - this is the configuration used by the AWS Amplify libraries
export const AwsConfig = {
    Auth: {
        identityPoolId: AppConfig.Aws.IdentityPoolId,
        region: AppConfig.Aws.Region,
        identityPoolRegion: AppConfig.Aws.Region,
        userPoolId: AppConfig.Aws.UserPoolId,
        userPoolWebClientId: AppConfig.Aws.ClientId,
        mandatorySignIn: false,
        authenticationFlowType: "USER_SRP_AUTH"
    },
    API: {
        endpoints: [
        ]
    }
}

for (const item in AppConfig.Aws.ApiGateways) {
    let gateway = AppConfig.Aws.ApiGateways[item];
    console.log(gateway);
    //ex: https://8k6ilqsirk.execute-api.us-east-1.amazonaws.com/Dev
    let port = (gateway.Port === 443) ? "" : ":" + gateway.Port;
    let url = gateway.Scheme + "://" + gateway.Id + "." + gateway.Service + "." + AppConfig.Aws.Region + "." + gateway.Host + port + "/" + gateway.Stage;
    console.log(url);
    switch (gateway.SecurityLevel) {
        case 0: // none
            AwsConfig.API.endpoints.push({ name: item, endpoint: url });
            break;
        case 1: // JWT
            AwsConfig.API.endpoints.push({ name: item, endpoint: url, custom_header: async () => { return { Authorization: (await Auth.currentSession()).getIdToken().getJwtToken() }; } });
            break;
        case 2: // AwsSignatureVersion4
            AwsConfig.API.endpoints.push({ name: item, endpoint: url, custom_header: async () => { return { LzIdentity: (await Auth.currentSession()).getIdToken().getJwtToken() }; } });
            break;
        default:
            break;
    }
}