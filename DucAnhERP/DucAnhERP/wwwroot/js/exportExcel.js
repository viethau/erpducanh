window.downloadFileFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    const anchor = document.createElement('a');
    anchor.href = url;
    anchor.download = fileName || 'ExportedData.xlsx';
    anchor.click();
    URL.revokeObjectURL(url);
};

//function saveFileFromBase64(fileName, base64Data) {
//    const link = document.createElement("a");
//    link.download = fileName;
//    link.href = `data:application/octet-stream;base64,${base64Data}`;
//    document.body.appendChild(link);
//    link.click();
//    document.body.removeChild(link);
//}