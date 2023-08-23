$(document).ready(function () {
    setEditEmployeeModalPhotos();
});

function setEditEmployeeModalPhotos() {
    var fileElementId = "IPhoto_";
    var photoElementId = "IPhotoDisplay_";
    const imageInput = document.getElementById(fileElementId);
    const previewImage = document.getElementById(photoElementId);
    imageInput.addEventListener('change', function (event) {
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