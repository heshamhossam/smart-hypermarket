package com.hci.smarthypermarket;

import java.util.ArrayList;
import java.util.List;
import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONException;
import org.json.JSONObject;
import android.os.AsyncTask;

abstract class RetrieveProductTask extends AsyncTask<String, Integer, Product> {

	// ////////////////////////////
	final String TAG_PID = "id";
	final String TAG_NAME = "name";
	final String TAG_BARCODE = "barcode";
	final String TAG_PRICE = "price";
	final String TAG_CATID = "category_id";
	final String TAG_SUCCESS = "success";
	final String TAG_PRODUCT = "product";
	// //////////////////////////////////

	JSONParser jsonParser = new JSONParser();

	private static final String url_product_detials = "http://zonlinegamescom.ipage.com/smarthypermarket/public/products/retrieve";

	private Product p = new Product();

	@SuppressWarnings("finally")
	@Override
	protected Product doInBackground(String... params) {

		// TODO Auto-generated method stub
		try {
			int success;

			List<NameValuePair> CParams = new ArrayList<NameValuePair>();
			CParams.add(new BasicNameValuePair("barcode", params[0]));

			JSONObject json = jsonParser.makeHttpRequest(url_product_detials,
					"GET", CParams);

			success = json.getInt(TAG_SUCCESS);
			if (success == 1) {

				JSONObject productObj = json.getJSONObject(TAG_PRODUCT);
				String id = productObj.getString(TAG_PID);
				String name = productObj.getString(TAG_NAME);
				String barcode = productObj.getString(TAG_BARCODE);
				float price = Float.parseFloat(productObj.getString(TAG_PRICE));
				String categoryId = productObj.getString(TAG_CATID);
				
				p = new Product(id, name, barcode, price, categoryId);

				return p;
			} else {
			}
		} catch (JSONException e) {
			e.printStackTrace();
		} finally {
			return p;
		}
	}

}

public abstract class WebService implements IWebService {

	abstract protected void onProductDetected(Product product);

	// ///////////////////////////////////////////////////////
	@Override
	public void getProduct(final String barcode) {
		RetrieveProductTask retrieveProduct = new RetrieveProductTask() {
			protected void onPostExecute(Product result) {
				onProductDetected(result);
			}
		};

		retrieveProduct.execute(barcode);
	}

}
