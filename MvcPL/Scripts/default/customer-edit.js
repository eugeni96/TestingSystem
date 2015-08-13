function CustomerEdit() {
    _this = this;

    this.ajaxAddOption = "/Question/AddOption";

    this.init = function () {
        $("#AddOption").click(function () {
            $.ajax({
                type: "GET",
                url: _this.ajaxAddOption,
                success: function (data) {
                    $("#OptionListWrapper").append(data);
                }
            })
        });

        $(document).on("click", ".remove-line", function () {
            $(this).closest(".OptionWrapper").remove();
        });
    }
}

var customerEdit = null;
$().ready(function () {
    customerEdit = new CustomerEdit();
    customerEdit.init();
});