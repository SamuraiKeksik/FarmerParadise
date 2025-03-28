function send() {
    fetch("/Api/Referral/Check", {
        method: "POST",
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
            'Content-Type': 'application/json'
        },

        //make sure to serialize your JSON body
        body: JSON.stringify({
            referralLink: document.getElementById("sendInput").value
        })
    })
        .then(response => { 
            if (response.ok) {
                console.log("OK");
                return response.json();
            }
            else {
                console.log("false");
            }
        }).
        then(data => {
            console.log(data);
        })
    }