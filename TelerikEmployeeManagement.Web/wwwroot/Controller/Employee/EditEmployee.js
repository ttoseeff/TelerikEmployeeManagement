$(document).ready(function () {

    actualVal = document.getElementById("iHiddenDOB").value;
    console.log(actualVal,'actualVal')
    // Get the input element
    var dateOfBirthInput = document.getElementById("dateOfBirthInput");
    // Get the selected date from the input
    var selectedDate = new Date(actualVal);

    // Format the date as yyyy-mm-dd
    var formattedDate = selectedDate.toISOString().split("T")[0];

    // Set the formatted date back to the input value
    dateOfBirthInput.value = formattedDate;

    // Attach a change event listener
    dateOfBirthInput.addEventListener("change", function () {
        // Get the selected date from the input
        var selectedDate = new Date(actualVal);

        // Format the date as yyyy-mm-dd
        var formattedDate = selectedDate.toISOString().split("T")[0];

        // Set the formatted date back to the input value
        dateOfBirthInput.value = formattedDate;
    });

    setEditEmployeeModalPhotos();

});

function setEditEmployeeModalPhotos() {
    var fileElementId = "IPhoto_";
    var photoElementId = "IPhotoDisplay_";


    const imageInput = document.getElementById(fileElementId);
    const previewImage = document.getElementById(photoElementId);

    imageInput.addEventListener('change', function (event) {
        console.log("invoked")
        const selectedFile = event.target.files[0];

        if (selectedFile) {
            // Read the selected image as a data URL
            const reader = new FileReader();
            reader.onload = function (event) {
                // Update the image source with the data URL
                previewImage.src = event.target.result;
                previewImage.style.display = 'block'; // Show the image
            };
            reader.readAsDataURL(selectedFile); // Read the selected file as data URL
        } else {
            // No file selected, hide the image
            previewImage.style.display = 'none';
            previewImage.src = '';
        }
    });
}