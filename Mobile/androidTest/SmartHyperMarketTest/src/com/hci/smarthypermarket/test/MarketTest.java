package com.hci.smarthypermarket.test;

import com.hci.smarthypermarket.Market;

import android.location.Location;
import android.test.AndroidTestCase;


public class MarketTest extends AndroidTestCase {
	
	public void testConstructor()
	{
		Market market =  new Market(1, "Metro");
		assertEquals(market.getId(), 1);
	}
	public void testConstructor2(){
		Location location = new Location("marker");
		location.setLongitude(31.1522816);
		location.setLatitude(30.0059012);
		Market market = new Market(location);
		assertEquals(market.getId(), 1);
		
	}

}
