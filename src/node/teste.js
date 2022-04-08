const axios = require('axios')

function checkHealthCheck() {
    axios
        .get('http://localhost:5147/health_check')
        .then(res => {
            console.log(`statusCode: ${res.status}`)
            if (res.status == 200) {
                console.log('online')
                return;
            } else {
                console.log('error')
            }
        })
        .catch(error => {
            //console.error(error)
            console.log('offline')            
        })
}


(async () => {
    checkHealthCheck();
})().catch(e => {
    console.log(e)
});