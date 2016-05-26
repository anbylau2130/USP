(function () {
    usp.namespace("usp.corporation.editCorporation");
    usp.corporation.editCorporation = {
        init: function (btnReturnId, provinceId, areaId, areaUrl, countyId, countyUrl, basePage) {
            $(".datepicker").datetimepicker({
                format: 'YYYY-MM-DD'
            });
           // usp.corporation.editCorporation.eventInit.btnReturnInit(btnReturnId, basePage);
           // usp.corporation.editCorporation.eventInit.provinceChange(areaId, areaUrl, provinceId, countyId);
            //usp.corporation.editCorporation.eventInit.areaChange(countyId, countyUrl, areaId);
        },
        eventInit: {
            btnReturnInit: function (id, basePage) {
                $(id).on("click", function () {
                    location.href = basePage;
                    return false;
                });
            },
            provinceChange: function (areaId, url, provinceId, countyId) {
                $(provinceId).on("change", function () {
                    $.ajax({
                        type: "POST",
                        url: url + "?provinceCode=" + $(provinceId).val(),
                        success: function (data) {
                            $(areaId).empty();
                            $.each(data, function (i, item) {
                                $("<option></option>")
                                    .val(item.id)
                                    .text(item.text)
                                    .appendTo($(areaId));
                            });
                            $(countyId).empty();
                        }
                    });
                });
            },
            areaChange: function (countyId, url, cityId) {
                $(cityId).on("change", function () {
                    $.ajax({
                        type: "POST",
                        url: url + "?areaCode=" + $(cityId).val(),
                        success: function (data) {
                            $(countyId).empty();
                            $.each(data, function (i, item) {
                                $("<option></option>")
                                    .val(item.id)
                                    .text(item.text)
                                    .appendTo($(countyId));
                            });
                        }
                    });
                });
            }
        }
    }
})(this);