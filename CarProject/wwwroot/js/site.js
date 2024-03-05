// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addCar() {
    var std =
    {
        'carId': 0,
        'Year': parseInt(document.getElementById("CarYear").value),
        'Make': document.getElementById("CarMake").value,
        'Model': document.getElementById("CarModel").value
    };
    //var jsonString = JSON.stringify(std);
    try
    {
        $.ajax(
            {
                url: '/Car/AddNewCar',
                type: 'GET',
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                data: std,//JSON.stringify({ "carObj": "std" }),//{ 'carObj': jsonString },
                success: function () {
                    alert("successfully added");
                    UpdateCarTable();
                },
                error: function () {
                    console.log(ex);
                    alert("An error occurred while adding car to list.");
                }
            });
    }
    catch (error) {
        alert(erorr)
    }
    return false;
}

function UpdateCarTable()
{
    //alert("here in updateCarTable");
    $("#carTable tbody tr").remove();
    $.ajax(
        {
            url: '/Car/GetCarList',
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            //data: { id: '' },
            success: function (data) {
                var lst = data.carList;
                var items = '';
                $.each(lst, function (i, item) {
                    var rows =
                        "<tr>" +
                        "<td class='productth'>" + item.carId + "</td>" +
                        "<td class='productth'>" + item.year + "</td>" +
                        "<td class='productth'>" + item.make + "</td>" +
                        "<td class='productth'>" + item.model + "</td>" +
                        "</tr>";

                    $("#carTable tbody").append(rows);
                })
            },
            error: function (ex) {
                console.log(ex);
                alert("An error occurred while fetching car list.");
            }
        });
    //return false;
}

function test()
{
    var testString = document.getElementById("TestInp").value;
    jsonString = JSON.stringify(testString);
    $.ajax({
        url: '/Car/testFunction',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: { testString2: testString },
        success: function (data) {
            alert(data.testString2);
        },
        error: function (ex) {
            console.log(ex);
            alert("An error occurred while fetching car list.");
        }
    });
}

function test2() {

    alert('test2');

    var testObj = {
        'Id': 1,
        'Name': 'John'
    };

    $.ajax({
        url: '/Car/testFunctionEx',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: testObj,
        success: function (data) {
            alert(data.result);
        },
        error: function (ex) {
            console.log(ex);
            alert("An error occurred while fetching car list.");
        }
    });
}