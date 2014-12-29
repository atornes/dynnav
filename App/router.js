"use strict";

(function(w,d){
	var apiUrl = "api/route?path="
	
	function replaceAll(find, replace, str) {
		return str.replace(new RegExp(find, 'g'), replace);
	}

	function routeChange() {
		var path = w.location.hash.slice(2) || '/';
		xget(apiUrl + path, routeLoaded);
	}

	function routeLoaded(){
		if (this.status === 200){
			var navItem = JSON.parse(this.response);
			loadView(navItem.ViewPath);
		}
		else {
			w.location.hash = "!/404";
		}
	}

	function loadView(viewPath){
		xget(viewPath, setView);
	}

	function setView(){
		if (this.status === 200){
			var viewBody = d.getElementById("viewBody");
			viewBody.innerHTML = this.response;
		}
		else {
			w.location.hash = "!/404";
		}
	}

	function xget(url, callback){
		var oReq = new XMLHttpRequest();
		oReq.onload = callback;
		oReq.open("get", url, true);
		oReq.send();
	}

	w.addEventListener('hashchange', routeChange);
	w.addEventListener('load', routeChange);
})(window, window.document);