$("#CityId").selectize({
	plugins: ["remove_button"],
	valueField: "id",
	labelField: "name",
	searchField: "name",
	placeholder: "введите текст",
	options: [],
	maxItems: 3,
	persist: false,
	create: false,

	load: function (query, callback) {
		if (!query.length) {
			return callback();
		}

		$.get("/api/City/find/" + query,
			function (data) {
				if (data.length > 0) {
					$("#CityId option").remove();

					for (var i = 0; i < data.length; i++) {
						$("#CityId").append(
							"<option value=\"" + data[i].id + "\">" +
							data[i].name + "</option>");
					}

					callback(data);
				}
			}, "json");
	}
});