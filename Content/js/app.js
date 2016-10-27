var $app = {
    defs: {
        contentType: "application/x-www-form-urlencoded",
        method: "POST",
        converters: {
            "text json": function (text) {
                return eval("(" + text.replace(/[\n\r]+/gi, ' ') + ")");
            }
        }
    },
    init: function () {
        $.ajaxSetup($app.defs);
    }
}
$("body").ready($app.init);