let copyButton = document.getElementById('copy-button');
copyButton.addEventListener("click", function () {
    navigator.clipboard
        .writeText(document.getElementById("input-field").value)
        .then(
            (success) => console.log("text copied"),
            (err) => console.log("error copying text")
        );
});