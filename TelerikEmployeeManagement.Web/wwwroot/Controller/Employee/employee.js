/// <reference path="../../lib/jquery/dist/jquery.js" />

$(document).ready(function () {

    const imageInput = document.getElementById('IAddPhoto');
    const previewImage = document.getElementById('IPhotoDisplay');

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

});

function deleteEmployee(employeeId) {
    var url = "/Employee/DeleteEmployee";
    $.get(url, { EmployeeId: employeeId }, function (data) {
        window.location.href = "/Employee/listing-simple";
    })
}

function editEmployee(employeeId) {
    var url = "/Employee/EditEmployee";
    $.get(url, { EmployeeId: employeeId }, function (data) {
        $("#IEditForm").html(data);
    })
}

function editEmployeeTelerik(employeeId) {
    var url = "/Employee/EditEmployee";
    //$.get(url, { EmployeeId: employeeId, isTelerik: true }, function (data) {
    //    $("#IEditForm").html(data);
    //})
   
    $.ajax({
        url: "/Employee/RenderEditEmployee", // Replace with your actual controller and action
        method: "GET",
        data: { employeeId: employeeId},
        success: function (data) {
            // Successfully loaded the partial view
            // Insert the content into the container
            $("#IEditForm").html(data);

            // If you have initialization code for Telerik UI controls, call it here
            // For example: InitializeTelerikControls();
        },
        error: function (xhr, status, error) {
            // Handle error if the AJAX call fails
            console.error("Error loading partial view:", error);
        },
        complete: function (data) {
            console.log(data);
            $("#IEditForm").html(data.responseText);
        }
    });
}

//function editEmployee(employeeId) {
//    var url = "/Employee/EditEmployee";
//    $.get(url, { EmployeeId: employeeId }, function (data) {
//        console.log(data, "data");
//        $("#EditEmployee_FirstName").val(data.firstName)
//        $("#EditEmployee_EmployeeId").val(data.employeeId)
//        $("#EditEmployee_LastName").val(data.lastName)
//        $("#EditEmployee_Email").val(data.email)
//        $("#EditEmployee_DateOfBrith").val(new Date(data.dateOfBrith).toISOString().split('T')[0])
//        $("#EditEmployee_DepartmentId").val(data.departmentId)
//        $("#EditEmployee_EmployeeId").val(data.employeeId)
//        $("#IPhotoDisplay_").attr('src', '/' + data.photoPath)
//        if (data.gender == 0) {
//            $("#Edit_Employee_Gender_Male").attr("checked", "checked")

//        } else if (data.gender == 1) {
//            $("#Edit_Employee_Gender_Female").attr("checked", "checked")

//        } else if (data.gender == 2) {
//            $("#Edit_Employee_Gender_Other").attr("checked", "checked")

//        }
//    })
//}



