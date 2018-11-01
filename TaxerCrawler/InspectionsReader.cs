using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using TaxerCrawler.Models;

namespace TaxerCrawler
{
	public class InspectionsReader
	{
		private readonly IHttpClientFactory _httpClientFactory;

		private string _getInspectionsUri = "https://taxer.ua/ru/data/region/dpa_options";

		public InspectionsReader()
		{
			var serviceProvider =  AddHttpClient();
			_httpClientFactory = serviceProvider.Reso<IHttpClientFactory>();
		}

		public IEnumerable<TaxerInspection> GetInspections(int regionId)
		{
			
			using (HttpClient client = new HttpClient())
			{
				/*
				client.BaseAddress = new Uri(_getInspectionsUri);
				client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
				client.*/
			}

			yield return null;
		}
	}
}
