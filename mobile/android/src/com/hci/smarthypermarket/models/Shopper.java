package com.hci.smarthypermarket.models;

import java.util.ArrayList;
import java.util.List;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.AsyncTask;
import android.os.Bundle;
import android.widget.Toast;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONException;
import org.json.JSONObject;



abstract class  SendOrderTask extends AsyncTask<Shopper,Integer, Order>
{
	final String TAG_UFName="first_name";
	final String TAG_ULName="last_name";
	final String TAG_MNum ="mobile";
	final String TAG_MID="market_id";
	final String TAG_PID="product_id";
	final String TAG_PQUN="product_quantity";
	private static final String url_order_details= Model.linkServiceRoot + "/orders/create";
	JSONParser jsonParser = new JSONParser();
	@Override
	protected Order doInBackground(Shopper... params) {
		try {
			List<NameValuePair> CParams = new ArrayList<NameValuePair>();
			CParams.add(new BasicNameValuePair(TAG_UFName,params[0].getFirstName()));
			CParams.add(new BasicNameValuePair(TAG_ULName, params[0].getLastName()));
			CParams.add(new BasicNameValuePair(TAG_MNum,params[0].getMobile()));
			CParams.add(new BasicNameValuePair(TAG_MID, params[0].getMarketId()));
			for(int i =0;i<params[0].getOrder().getProducts().size();i++)
			{
				
				CParams.add(new BasicNameValuePair(TAG_PID+Integer.toString(i), params[0].getOrder().getProducts().get(i).getId()));
				CParams.add(new BasicNameValuePair(TAG_PQUN+Integer.toString(i),Integer.toString(params[0].getOrder().getProducts().get(i).getPurchasedQuantity())));
			}
			
			
			JSONObject json = jsonParser.makeHttpRequest(url_order_details,
					"GET", CParams);
			
				params[0].getOrder().setId(json.getString("id"));
				params[0].getOrder().setConfirmationCode(json.getString("confirmation_code"));
				params[0].getOrder().setState(json.getString("state"));
				
				return params[0].getOrder();
			} catch (JSONException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		return null;
	}
	
	
}


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

public class Shopper extends Model {
	
	
	private Product scannedProduct;
	private Order order = new Order();
	private Location location = null;
	private String marketId;
	private String mobile;
	private String firstName;
	private String LastName;
	private static Shopper MainShopper;
	BluetoothAdapter mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
	BroadcastReceiver mReceiver;
	
	private Bluetooth BluetoothObject;
	
	public Shopper(Context context) 
	{
		try
		  {
		   TelephonyInfo telephonyInfo = TelephonyInfo.getInstance(context);
		      mobile = telephonyInfo.getImeiSIM1();
		  }
		  catch(Exception e)
		  {
		      mobile = "60383216";
		  }
	    
	}
	public Shopper(String fistName,String lastName,String mobile)
	{
		this.firstName=fistName;
		this.LastName=lastName;
		this.mobile=mobile;
		
	}
	
	public void trackPosition(Context activity)
	{
		LocationManager locationManager = (LocationManager)activity.getSystemService(Context.LOCATION_SERVICE);
		LocationListener locationListener = new PersonlocationListener() {
			@Override
			public void onLocationChanged(Location newLocation) {
				location = newLocation;
				modelHandler.OnModelLocationChange();
			}
		};
		
		List<String> providers = locationManager.getProviders(true);
		
		for (int i = 0; i < providers.size(); i++)
		{
			locationManager.requestLocationUpdates(providers.get(i), 0, 0, locationListener);
		}
		
	}
	
	public void startBlutoothTracking(final Context activityContext, final OnBluetoothListener bluetoothListener)
	{
		
		Toast.makeText(activityContext, "Searching In Market Sections...", Toast.LENGTH_LONG).show();
		mBluetoothAdapter.startDiscovery();
		/* Search for bluetooth */
		mReceiver = new BroadcastReceiver(){
			@Override
			public void onReceive(Context context, Intent intent) {
				String action = intent.getAction();
				// Finding Devices
				if(BluetoothDevice.ACTION_FOUND.equals(action)){
					BluetoothDevice device = intent.getParcelableExtra(BluetoothDevice.EXTRA_DEVICE);
					int bluetoothstrength = intent.getShortExtra(BluetoothDevice.EXTRA_RSSI,Short.MIN_VALUE);
					
					// Define bluetooth object
					BluetoothObject = new Bluetooth(device.getName(), device.getAddress(), bluetoothstrength);
					bluetoothListener.onBlutoothFound(BluetoothObject);
				}
			}
			
		};
		
		IntentFilter filter = new IntentFilter(BluetoothDevice.ACTION_FOUND);
		activityContext.registerReceiver(mReceiver, filter);
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

	public String getFirstName() {
		return firstName;
	}

	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}

	public String getLastName() {
		return LastName;
	}

	public void setLastName(String lastName) {
		LastName = lastName;
	}

	public static Shopper getMainShopper() {
		return MainShopper;
	}

	public void setMobile(String mobile) {
		this.mobile = mobile;
	}
	
	public void submitOrder(final OnModelListener onModelHandler)
	{
		SendOrderTask sendOrderTask = new SendOrderTask() {

			@Override
			protected void onPostExecute(Order order) {
				setOrder(order);
				onModelHandler.OnModelSent();
			}
			
		};
		sendOrderTask.execute(this);
		
		
	}
	
	public Boolean isConnectedToInternet(Context context)
	{
		ConnectivityManager connectivityManager = (ConnectivityManager) context.getSystemService(Context.CONNECTIVITY_SERVICE);
		NetworkInfo networkInfo = connectivityManager.getActiveNetworkInfo();
		return (networkInfo != null && networkInfo.isConnected());
	}
	

}
