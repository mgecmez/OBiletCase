function initIndex() {
    loadLocations();
    loadDate();
}

function loadLocations() {
    var selectedOriginLocationId = 0;
    var selectedDestinationLocationId = 0;

    var selectedCookie = undefined;
    var selectedCookieJson = $.cookie("search-location");
    if (selectedCookieJson) {
        selectedCookie = JSON.parse(selectedCookieJson);
    }

    $("#ddlOriginLocations").select2({
        theme: "classic",
        placeholder: "",
        selectOnClose: true,
        allowClear: true,
        ajax: {
            url: 'Home/GetBusLocations',
            type: 'GET',
            dataType: 'json',
            delay: 250,
            data: function (params) {
                var query = {
                    search: params.term
                }

                return query;
            },
            processResults: function (data) {
                return {
                    results: $.map(data, function (obj) {
                        obj.id = obj.id;
                        obj.text = obj.name;
                        return obj;
                    })
                };
            }
        }
    });

    $("#ddlDestinationLocations").select2({
        theme: "classic",
        placeholder: "",
        selectOnClose: true,
        allowClear: true,
        ajax: {
            url: 'Home/GetBusLocations',
            type: 'GET',
            dataType: 'json',
            delay: 250,
            data: function (params) {
                var query = {
                    search: params.term
                }

                return query;
            },
            processResults: function (data) {
                return {
                    results: $.map(data, function (obj) {
                        obj.id = obj.id;
                        obj.text = obj.name;
                        return obj;
                    })
                };
            }
        }
    });

    $('#ddlOriginLocations').on('select2:select', function (e) {
        var originLocationId = e.params.data.id;
        var destinationLocationId = $('#ddlDestinationLocations').select2('data')[0].id;

        if (originLocationId == destinationLocationId) {
            $('#ddlDestinationLocations').val(selectedOriginLocationId).trigger('change.select2');
        } else {
            selectedOriginLocationId = originLocationId;
        }
    });

    $('#ddlDestinationLocations').on('select2:select', function (e) {
        var destinationLocationId = e.params.data.id;
        var originLocationId = $('#ddlOriginLocations').select2('data')[0].id;

        if (destinationLocationId == originLocationId) {
            $('#ddlOriginLocations').val(selectedDestinationLocationId).trigger('change.select2');
        } else {
            selectedDestinationLocationId = destinationLocationId;
        }
    });

    $.get('Home/GetBusLocations')
        .done(function (data) {
            var initials = $.map(data, function (obj) {
                return {
                    id: obj.id,
                    text: obj.name
                };
            });

            $("#ddlOriginLocations").select2({
                data: initials
            });

            $("#ddlDestinationLocations").select2({
                data: initials
            });

            if (!selectedCookie) {
                var selectedOriginLocation = initials[0];
                var selectedOriginCityId = data.find(x => x.id == selectedOriginLocation.id).cityId;

                var selectedDestinationLocation = data.filter(function (x) {
                    return x.cityId != selectedOriginCityId;
                }).map(function (obj) {
                    return {
                        id: obj.id,
                        text: obj.name
                    };
                })[0];

                selectedOriginLocationId = selectedOriginLocation.id;
                $('#ddlOriginLocations').val(selectedOriginLocationId).trigger('change.select2');

                selectedDestinationLocationId = selectedDestinationLocation.id;
                $('#ddlDestinationLocations').val(selectedDestinationLocationId).trigger('change.select2');

                $("#dpDeparture").datepicker("setDate", new Date());
            } else {
                selectedOriginLocationId = selectedCookie.originLocation;
                $('#ddlOriginLocations').val(selectedOriginLocationId).trigger('change.select2');

                selectedDestinationLocationId = selectedCookie.destinationLocation;
                $('#ddlDestinationLocations').val(selectedDestinationLocationId).trigger('change.select2');

                var departureDate = new Date(selectedCookie.departureDate);
                var today = new Date();
                if (departureDate >= today) {
                    $("#dpDeparture").datepicker("setDate", departureDate);
                } else {
                    $("#dpDeparture").datepicker("setDate", today);
                }
            }
        });

    $('#search').on('submit', function (event) {
        event.preventDefault();

        var values = $(this).serializeArray();

        if (values) {
            var data = {
                originLocation: values.find(x => x.name == 'origin-location').value,
                destinationLocation: values.find(x => x.name == 'destination-location').value,
                departureDate: values.find(x => x.name == 'departure-date').value
            }
            var departureDate = new Date(new Date(data.departureDate).setMinutes(new Date(data.departureDate).getTimezoneOffset() * -1)).toISOString().split('T')[0];

            $.cookie("search-location", JSON.stringify(data));

            window.location.href = `seferler/${data.originLocation}-${data.destinationLocation}/${departureDate}`;
        }
    });

    $('#change').on('click', function () {
        var originLocationId = $('#ddlOriginLocations').select2('data')[0].id;
        selectedOriginLocationId = originLocationId;

        var destinationLocationId = $('#ddlDestinationLocations').select2('data')[0].id;
        selectedDestinationLocationId = destinationLocationId;

        $('#ddlOriginLocations').val(selectedDestinationLocationId).trigger('change.select2');
        $('#ddlDestinationLocations').val(selectedOriginLocationId).trigger('change.select2');
    });
}

function loadDate() {
    $("#dpDeparture").datepicker({
        numberOfMonths: 2,
        dateFormat: 'DD, d MM, y',
        autoclose: true
    });
    $("#dpDeparture").datepicker("setDate", new Date());

    $("#today").on("click", function () {
        $('#dpDeparture').datepicker("setDate", new Date());
    });

    $("#tomorrow").on("click", function () {
        var date = new Date();
        date.setDate(date.getDate() + 1);

        $('#dpDeparture').datepicker("setDate", date);
    });
}

function backToIndex() {
    window.history.back();
}