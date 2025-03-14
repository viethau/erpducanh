﻿window.select2Blazor = {
    initSelect2: function (id, dotNetHelper) {
        $('#' + id).select2(); // Khởi tạo Select2

        // Lắng nghe sự kiện thay đổi
        $('#' + id).on('change', function (e) {
            var value = $(this).val();
            dotNetHelper.invokeMethodAsync('OnChangeHandlerFromJS', value);
        });

        // Đặt z-index cao hơn khi mở dropdown
        $('#' + id).on('select2:open', function () {
            $('.select2-container .select2-dropdown').css('z-index', 9999);
        });
    },
    destroySelect2: function (id) {
        const element = document.getElementById(id);
        if (element && $(element).hasClass('select2-hidden-accessible')) {
            $(element).select2('destroy');
        }
    }
};
