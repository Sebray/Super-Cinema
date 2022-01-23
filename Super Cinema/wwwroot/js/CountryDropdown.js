$("#CountryId").selectize({
	plugins: ["remove_button"],
	valueField: "id",
	labelField: "name",
	searchField: "name",
	placeholder: "введите текст",
	options: [],
	persist: false,
	create: false,

	load: function (query, callback) {
		if (!query.length) {
			return callback();
		}

		$.get("/api/Country/find/" + query,
			function (data) {
				if (data.length > 0) {
					$("#CountryId option").remove();

					for (var i = 0; i < data.length; i++) {
						$("#CountryId").append(
							"<option value=\"" + data[i].id + "\">" +
							data[i].name + "</option>");
					}

					callback(data);
				}
			}, "json");
	}
});