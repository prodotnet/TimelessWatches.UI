//a function for sorting
function sortProducts() {
    var sortCriteria = document.getElementById("sortCriteria").value;
    var sortOrder = document.getElementById("sortOrder").value;

    $.ajax({
        type: "POST",
        url: "Home.aspx/sortProducts",
        data: JSON.stringify({ sortBy: sortCriteria, ascending: sortOrder === "true" }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            document.getElementById("AllProducts").innerHTML = response.d;
        }
    });
}