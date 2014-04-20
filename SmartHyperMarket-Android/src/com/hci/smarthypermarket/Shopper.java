package com.hci.smarthypermarket;

import java.io.Serializable;

public class Shopper implements Serializable {
	
	private static final long serialVersionUID = -603687797803541014L;
	
	Product scannedProduct;
	Order order = new Order();
	
	
	public Product getScannedProduct() {
		return scannedProduct;
	}
	public void setScannedProduct(Product scannedProduct) {
		this.scannedProduct = scannedProduct;
	}
	public Order getOrder() {
		return order;
	}
	public void setOrder(Order order) {
		this.order = order;
	}
	
	
	

}
