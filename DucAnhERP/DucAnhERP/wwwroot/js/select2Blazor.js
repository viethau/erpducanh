
window.select2Blazor = {
    initSelect2: function (id, dotNetHelper) {
        $('#' + id).select2(); // Khởi tạo Select2

        // Lắng nghe sự kiện thay đổi
        $('#' + id).on('change', function (e) {
            var value = $(this).val();
            dotNetHelper.invokeMethodAsync('OnChangeHandlerFromJS', value);
        });
    }
};



