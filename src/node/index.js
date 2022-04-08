const RocketChatApi = require('rocketchat-api')
const axios = require('axios')

const myUsername = 'aleme'
const myPassword = 'aleme'

class RocketChat {
    constructor(username, password) {
        this.rocketChatClient = new RocketChatApi('http', '20.226.49.189', 80)
        this.login = false
        this.username = username
        this.password = password
        this.botUsername = "myalertbot"
        this.botPassword = "StrongPassword"
    }

    async checkLogin() {
        if (this.login === false) {
             Promise.resolve(this.rocketChatClient.login(this.username, this.password))
            this.login = true
        }
    }

    async sendAsync(roomId, message) {
         this.checkLogin()
        return  Promise.resolve(this.rocketChatClient.chat.postMessage({ roomId: roomId, text: message }))
    }

    async createBotUserAsync() {
        const userToAdd = {
            "name": "My Alert Bot",
            "email": "myalertbot@mydomain.com",
            "username": this.botUsername,
            "password": this.botPassword,
            "sendWelcomeEmail": false,
            "joinDefaultChannels": false,
            "verified": false,
            "requirePasswordChange": false,
            "roles": ["user"]
        };

        try {
             this.checkLogin()
             Promise.resolve(this.rocketChatClient.users.create(userToAdd))
        } catch (error) { }
    }

    async getChannelsAsync() {
         this.checkLogin()
        const response =  this.rocketChatClient.channels.listJoined({})
        return response.channels
    }

    async createNewChannelAsync(channelName) {
         this.checkLogin()
        const response =  this.rocketChatClient.channels.create(channelName)
        return response.channel
    }

    loginWithBot() {
        this.username = this.botUsername
        this.password = this.botPassword
        this.login = false
    }
}

async function main() {
    console.log("[LOG] Entrando no Rocket Chat")
    rocketChat = new RocketChat(myUsername, myPassword)

    console.log("[LOG] Pegando o Id do Channel")
    const channels =  rocketChat.getChannelsAsync()
    let createNewChannel = false
    let channelId
    let channelName = "Report"
    // channels.forEach(channel => {
    //     if (channel.fname === channelName){
    //         console.log("[LOG] Usando o ID de um Channel antigo")
    //         createNewChannel = false
    //         channelId = channel._id
    //     }
    //})
    if (createNewChannel){
        console.log("[LOG] Criando um novo Channel")
        channel =  rocketChat.createNewChannelAsync(channelName)
        channelId = channel._id
    }

    console.log("[LOG] Criando um usuário para o Bot")
     rocketChat.createBotUserAsync()

    console.log("[LOG] Logando com o usuário do Bot")
    rocketChat.loginWithBot()

    axios
        .get('http://localhost:5147/health_check')
        .then(res => {
            //console.log(`statusCode: ${res.status}`)
            if (res.status == 200) {
                console.log('API ONLINE - STATUS ' + res.status)
                 rocketChat.sendAsync(channelId, "[SUCCESS] THE APPLICATION XPTO ONLINE")
            } else {
                console.log('API ERROR - STATUS ' + res.status)
                 rocketChat.sendAsync(channelId, "[WARNING] THE APPLICATION XPTO ERROR")
            }
        })
        .catch(error => {
            //console.error(error)
            console.log('API ERROR - OFFLINE')
             rocketChat.sendAsync(channelId, "[WARNING] THE APPLICATION XPTO SHUTDOWN")
        })

    console.log("[LOG] Fim da aplicação")
}

(async () => {
     main();
})().catch(e => {
    console.log(e)
});