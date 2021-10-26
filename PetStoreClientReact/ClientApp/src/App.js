import { AppConfig, AwsConfig } from "./AppConfig.js";
import React from "react";
import Amplify, { Auth, API } from "aws-amplify";
import { AmplifyAuthenticator, AmplifySignOut } from "@aws-amplify/ui-react";
import { PetStore } from "./PetStoreAxios";

// Initialize Amplify
Amplify.configure(AwsConfig);
const petStore = new PetStore(AppConfig); // Initialize the LazyStack generated ClientSDK

const App = () => (
    <AmplifyAuthenticator>
        <div>
            <button onClick={getUserViaAmplify}>GetUserViaAmplify</button>
            <button onClick={getUserViaLib}>GetUserViaLib</button>
            <button onClick={getPetViaAmplify}>GetPetViaAmplify</button>
            <button onClick={getPetViaLib}>GetPetViaLib</button>
            <AmplifySignOut />
        </div>
    </AmplifyAuthenticator>
);

async function getUserViaLib() {
    let user = await petStore.getUser();
    alert(user);
    console.log(user);
}

async function getPetViaLib() {
    let pet = await petStore.getPetById(1);
    alert(pet.name);
    console.log(pet.name);
}

async function getUserViaAmplify() {
    var apiName = 'HttpApiSecure';
    var path = '/pet/user';
    API
        .get(apiName, path)
        .then(response => {
            alert(response);
        })
        .catch(error => {
            console.log("the error", error);
        });
}

async function getPetViaAmplify() {
    var apiName = 'HttpApiSecure';
    var path = '/pet/1';
    API
        .get(apiName, path)
        .then(response => {
            alert(response.name);
        })
        .catch(error => {
            console.log("the error", error);
        });
}

export default App;
