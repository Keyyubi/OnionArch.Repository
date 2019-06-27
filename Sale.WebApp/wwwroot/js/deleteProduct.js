$('#deleteModal').on('shown.bs.modal', function (event) {
    let pId = $(event.relatedTarget).data('pid');
    let pName = $(event.relatedTarget).data('pname');

    let actionUrl = $('#modalForm').attr("action") + "?pId=" + pId;

    $('#modalProductId').val(pId);
    $('#modalProductName').val(pName);
    $('#modalForm').attr("action",actionUrl);
  });

  $('#addToChart').on('shown.bs.modal', function (event) {
    let pId = $(event.relatedTarget).data('pid');
    let maxVal = $(event.relatedTarget).data('maxv');
    
    let actionUrl = $('#addChartForm').attr("action") + "?pId=" + pId;

    $('#addChartProId').val(pId);
    $('#addChartAmount').attr({"max": maxVal});
    $('#addChartForm').attr("action",actionUrl);
  });