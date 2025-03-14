function scrollToFirstError() {
    // Tìm phần tử ValidationMessage đầu tiên có lỗi
    const firstError = document.querySelector(".validation-message:not(:empty)");
    if (firstError) {
        // Cuộn đến phần tử lỗi
        firstError.scrollIntoView({ behavior: "smooth", block: "center" });
        // Thêm hiệu ứng focus
        firstError.focus({ preventScroll: true });
        console.log("Scrolled to first error:", firstError);
    } else {
        console.log("No validation message found");
    }
}
console.log("Script loaded");
