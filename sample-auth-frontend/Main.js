function getUser() {
    fetch("https://localhost:5001/api/User", {
        method: "GET",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        credentials: "include"
    }).then(response => {
        return response.json();
    })
    .then(response => {
        document.querySelector("#welcome-message").innerHTML = "Hello, " + response.name;
    }).catch((err) => {
        document.body.innerHTML = err;
        document.body.style.color = "red";
    });
}

window.addEventListener("load", () => {
    fetch("https://localhost:5001/api/Login/", {
        method: "GET",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },   
        credentials: "include"
    }).then(response => {
        if (response.status !== 202) {
            window.location = "https://localhost:5001/api/Login/authenticate";
        } else {
            getUser();
        }
    }).catch((err) => {
        document.body.innerHTML = err;
        document.body.style.color = "red";
    });
});
