package com.hci.smarthypermarket;

import java.util.List;

import android.app.Activity;
import android.content.Context;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;

abstract class PersonlocationListener implements LocationListener
{

	@Override
	public void onProviderDisabled(String provider) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onProviderEnabled(String provider) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onStatusChanged(String provider, int status, Bundle extras) {
		// TODO Auto-generated method stub
		
	}
	
}

public class Shopper {
	
	
	private Product scannedProduct;
	private Order order = new Order();
	private Location location = null;
	private String marketId;
	private String mobile;
	private static Shopper MainShopper;
	
	public Shopper() { }
	
	public Shopper getInstance()
	{
		if (MainShopper == null)
			MainShopper = new Shopper();
		
		return MainShopper;
	}
	
	protected void onLocationChange()
	{
		;
	}
	
	public void trackPosition(Activity activity)
	{
		LocationManager locationManager = (LocationManager)activity.getSystemService(Context.LOCATION_SERVICE);
		LocationListener locationListener = new PersonlocationListener() {
			@Override
			public void onLocationChanged(Location newLocation) {
				location = newLocation;
				onLocationChange();
			}
		};
		
		List<String> providers = locationManager.getProviders(true);
		
		for (int i = 0; i < providers.size(); i++)
		{
			locationManager.requestLocationUpdates(providers.get(i), 0, 0, locationListener);
		}
		
	}
	
	public Location getLocation() {
		return location;
	}
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

	public String getMarketId() {
		return marketId;
	}

	public void setMarketId(String marketId) {
		this.marketId = marketId;
	}

	public String getMobile() {
		return mobile;
	}
	
	
	

}
