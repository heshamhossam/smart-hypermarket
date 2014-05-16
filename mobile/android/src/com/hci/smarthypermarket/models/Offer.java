package com.hci.smarthypermarket.models;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import com.hci.smarthypermarket.views.IShowableItem;

import android.os.AsyncTask;


abstract class RetriveOffersTask extends AsyncTask<Market,Integer,List<Offer>>
{
	///////////////////////////////////OffersTags////////////////////////
	final String Tag_Offers="offers";
	final String Tag_OfferName="name";
	final String Tag_OfferId="id";
	final String Tag_OfferPrice="price";
	final String Tag_OfferTeaser="teaser";
	final String Tag_OfferCreatedat="created_at";
	final String Tag_OfferUpdatedat="updated_at";
	///////////////////////////////////Products Tag Of Offer/////////////////////////////////
	
	final String Tag_Products="products";
	final String Tag_ProductId="id";
	final String Tag_ProductName="name";
	final String Tag_ProductBarcode="barcode";
	final String Tag_ProductDescription="description";
	final String Tag_ProductWeight="weight";
	final String Tag_ProductQuanatiy="quantity";
	////////////////////////////////////////////////////////
	List<Offer> offerslist=  new ArrayList<Offer>();
	List<Product> productslist;
	JSONArray offers= null;
	JSONArray products=null;
	JSONParser jsonParser = new JSONParser();
	private static final String url_offers_details=Model.linkServiceRoot+"/offers/retrieve";
	
	
	
	@Override
	protected List<Offer> doInBackground(Market... params) {
		// TODO Auto-generated method stub
		List<NameValuePair>Params= new ArrayList<NameValuePair>();
		Params.add(new BasicNameValuePair("market_id",params[0].getId())); 
		
		JSONObject jsonObject = jsonParser.makeHttpRequest(url_offers_details, "GET", Params);
		
		try {
			offers = jsonObject.getJSONArray(Tag_Offers);
			
			for(int i=0;i<offers.length();i++)
			{
				
				JSONObject offerjson= offers.getJSONObject(i);
				String offername= offerjson.getString(Tag_OfferName);
				String offerprice= offerjson.getString(Tag_OfferPrice);
				String offerteaser=offerjson.getString(Tag_OfferTeaser);
				String offerid=offerjson.getString(Tag_OfferId);
				String offercreatedat=offerjson.getString(Tag_OfferCreatedat);
				String offerupdatedat=offerjson.getString(Tag_OfferUpdatedat);
				products = offerjson.getJSONArray(Tag_Products);
				productslist = new ArrayList<Product>();
				for(int j =0;j<products.length();j++)
				{
				
					JSONObject productjson = products.getJSONObject(j);
					String productname=productjson.getString(Tag_ProductName);
					String productbarcode=productjson.getString(Tag_ProductBarcode);
					String productid= productjson.getString(Tag_ProductId);
					String productdiscription= productjson.getString(Tag_ProductDescription);
					String productwight= productjson.getString(Tag_ProductWeight);
					String productquanatiy= productjson.getString(Tag_ProductQuanatiy);
					Product product = new Product(productid, productname, productbarcode,Integer.parseInt(productquanatiy), productwight, productdiscription);
					
					productslist.add(product);
				}
				Offer offer = new Offer(offername,offerprice,offerteaser,offercreatedat,offerupdatedat,productslist);
				offerslist.add(offer);
			}
		} catch (JSONException e) {
			// TODO Auto-generated catch block
			//e.printStackTrace();
			return  null;
		}
		
		
			 return offerslist;
			
	   
	}
	
}
public class Offer extends Model implements IShowableItem {

	private String name;
	private String teaser;
	private String createdAt;
	private String updatedAt;
	private String offerprice;
	private int quantity;	
	private List<Product> products;
	private static List<Offer> allOffers;
	
	public Offer() {
		
	}
	public Offer(String name, String offerprice,String teaser,String createdat,String updatedat,List<Product> products)
	{
		this.name= name;
		this.offerprice= offerprice;
		this.teaser= teaser;
		this.createdAt= createdat;
		this.updatedAt= updatedat;
		this.products= products;
		
	}
	
	public static void all(Market market, final OnModelListener onOffersRetrieved)
	{
		
		RetriveOffersTask retriveOffersTask = new RetriveOffersTask() {
			protected void onPostExecute(List<Offer>list)
			{
				isAllFetched = true;
				allOffers = list;
				onOffersRetrieved.OnModelRetrieved();
			}
		};
		
		retriveOffersTask.execute(market);
	}
	public List<Product> getProducts() {
		return products;
	}
	public static List<Offer> getAllOffers() {
		
		if (isAllFetched)
			return allOffers;
		
		return null;
	}
	
	@Override
	public String getName() {
		return name;
	}
	@Override
	public String getQuantity() {
		return String.valueOf(quantity);
	}
	@Override
	public String getPrice() {
		return offerprice;
	}
	public String getTeaser() {
		return teaser;
	}

}
