package com.hci.smarthypermarket;

import android.util.Log;




public class Product {
	
	protected String id;
	protected String name;
	protected String barcode;
	protected float price;
	protected String categoryId;
	protected int purchasedQuantity;
	private String description;
	private String weight;
	
	public Product()
	{
		
	}
	
	protected void onProductRetrieved()
	{
		Log.d("hesham", "Done");
	}
	
	public Product(String barCode) {
		WebService webService = new WebService() {

			@Override
			protected void onProductDetected(Product product) {
				id = product.getId();
				name = product.getName();
				barcode = product.getBarcode();
				price = product.getPrice();
				description = product.getDescription();
				weight = product.getWeight();
		//		categoryId = product.getCategoryId();
				
				onProductRetrieved();
				
			}
			
		};
		
		webService.getProduct(barCode);
		
//		
		
		
	}
	
	public String getId() {
		return id;
	}

	public String getCategoryId() {
		return categoryId;
	}

	public Product(String id, String name, String barcode, float price,String weight,String discription) {
		this.id = id;
		this.name = name;
		this.barcode = barcode;
		this.price = price;
		this.description= discription;
		this.weight = weight;
		//this.categoryId = categoryID;
	}
	
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getBarcode() {
		return barcode;
	}
	public void setBarcode(String barcode) {
		this.barcode = barcode;
	}
	public float getPrice() {
		return price;
	}
	public void setPrice(int price) {
		this.price = price;
	}
	public int getPurchasedQuantity() {
		return purchasedQuantity;
	}
	public void setPurchasedQuantity(int purchasedQuantity) {
		this.purchasedQuantity = purchasedQuantity;
	}
	
	public float getTotalPrice()
	{
		return purchasedQuantity * price;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getWeight() {
		return weight;
	}

	public void setWight(String wight) {
		this.weight = wight;
	}
	
}
