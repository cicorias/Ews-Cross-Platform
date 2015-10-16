'use strict;'

var https = require('https');
var request = require('request');
var promptly = require('promptly');
var fs = require('fs');

var Q = require('q');
var prompt = Q.denodeify(promptly.prompt);
var password = Q.denodeify(promptly.password);

prompt('Name')
	.then(function (name) {
		password('Password: ')
	.then(function (password) {
		var tAuth = name + ':' + password;
		var encoded = new Buffer(tAuth).toString('base64')
		return encoded;
	})
	.then(function(a,b){
		console.log(a);
		
		var bodyXml = fs.readFileSync('soapTemplate.xml');
		
		var options = {
			url: 'https://outlook.office365.com',
			path:'/EWS/Exchange.asmx',
			method:'POST',
			headers: {},
			body: bodyXml
		};
		
		
		request( options , function (error, response, body){
			if (error) {
				console.error(error);
			}
			else {
				console.log(response.statusCode, body);
			}
		});
		
	});
});





