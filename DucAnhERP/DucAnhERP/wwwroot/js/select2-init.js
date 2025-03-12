window.initializeSelect2 = (selectId, dotNetHelper) => {
    $(`#${selectId}`)
        .select2({
            tags: true,
            placeholder: 'Chọn hoặc nhập tag...',
            theme: 'classic'
        })
        .on('change', function () {
            const selectedValues = $(this).val() || [];
            if (dotNetHelper) {
                dotNetHelper.invokeMethodAsync('OnSelect2Change', selectedValues);
            } else {
                console.error('dotNetHelper is undefined!');
            }
        });
};
