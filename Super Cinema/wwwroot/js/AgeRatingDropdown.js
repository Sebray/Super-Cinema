$("#AgeRatingId").selectize({
	plugins: ["remove_button"],
	valueField: "id",
	labelField: "rating",
	searchField: "rating",
	placeholder: "введите текст",
	options: [],
	persist: false,
	create: false,

	load: function (query, callback) {
		if (!query.length) {
			return callback();
		}

		$.get("/api/AgeRating/find/" + query,
			function (data) {
				if (data.length > 0) {
					$("#AgeRatingId option").remove();

					for (var i = 0; i < data.length; i++) {
						$("#AgeRatingId").append(
							"<option value=\"" + data[i].id + "\">" +
							data[i].rating + "</option>");
					}

					callback(data);
				}
			}, "json");
	}
});