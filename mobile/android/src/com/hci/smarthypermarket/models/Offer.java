package com.hci.smarthypermarket.models;

import java.util.List;

public class Offer extends Model {

	private String name;
	private String teaser;
	private String createdAt;
	private String updatedAt;
	private List<Product> products;
	private List<Offer> allOffers;
	
	public Offer() {
		
	}
	
	public static void all(Market market)
	{
		
//		RetriveOffersTask retriveOffersTask = new RetriveOffersTask() {
//			protected void onPostExecute(List<Offer>list)
//			{
//				isAllFetched = true;
//				allOffers = list;
//				OnAllModelsRetrieved.OnModelRetrieved();
//			}
//		};
//		retriveOffersTask.execute(market);
	}

}
