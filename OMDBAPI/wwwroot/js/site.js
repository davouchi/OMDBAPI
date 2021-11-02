// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


//Display search results

function quickSearch() {
    var movName = $("#movName").val();

    if (movName === "") {
        $.notify({
            title: 'Error',
            message: 'Movie name is empty'
        }, {
            type: 'danger'
        });
        return;
    }

    try {
        $.ajax({
            type: "GET",
            url: "/omdbapi/movie-search/"+ movName,           
            success: function (resp) {

              if (resp !== null) {
                    $.notify({
                        title: 'Success',
                        message: 'Retrieving search results'
                    }, {
                        type: 'primary'
                    });

                    $("#searchResults").html(resp);
                }
                else {                  


                    $.notify({
                        title: 'Error',
                        message: 'Error occured please try again later or contact support'
                    }, {
                        type: 'danger'
                    });


                }
            }
        });
    }
    catch (err) {
        
        //Log client side error to provider
        $.notify({
            title: '<strong>Error</strong>',
            message: 'Error occured please try again later or contact support'
        }, {
            type: 'danger'
        });

    }
}