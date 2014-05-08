package com.hci.smarthypermarket;

import java.util.List;

import android.util.Log;

public class Category {
	
	protected String id;
	protected String name;
	protected String createdAt;
	protected String updatedAt;
	protected String parentId;
	
	protected List<Product> products;
	
	


	public Category(String id, String name )
	{
		this.id = id;
		this.name = name;
	
	}
	
	
	public String getId() {
		return id;
	}
	public String getName() {
		return name;
	}
	public String getCreatedAt() {
		return createdAt;
	}
	public String getUpdatedAt() {
		return updatedAt;
	}
	public String getParentId() {
		return parentId;
	}
	
	public List<Product> getProducts() {
		return products;
	}


	public void setProducts(List<Product> products) {
		this.products = products;
	}
	
	

}
