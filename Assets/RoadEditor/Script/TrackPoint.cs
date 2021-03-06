using UnityEngine;

[ExecuteInEditMode]
public class TrackPoint : MonoBehaviour{

	//trackData
    public int width = 25;
    public int height = 5;

	//bind point
	public Transform bindPoint;
	public bool flipBindPointYRotation = true;

	private TrackPoint bindPointScript;

	[SerializeField]
	[HideInInspector]
	public Vector3 checkPosition;
	[SerializeField]
	[HideInInspector]
	public Quaternion checkRotation;
	[SerializeField]
	[HideInInspector]
    public int checkWidth;
    [SerializeField]
    [HideInInspector]
    public int checkHeight;

	private bool updatePoint;

	private void Start(){
		checkPosition = transform.position;
		checkRotation = transform.rotation;
        checkWidth = width;
        checkHeight = height;
	}
	
	// uncomment if u want to edit in play mode
	/*private void FixedUpdate(){
		Loop ();
	}*/

	public void EditortUpdate(){
		Loop ();
	}

	int timer = 0;
	public void Loop(){
		timer++;
		if (timer % 100 == 0) {
			BindPointLoop();
		}
	}

	private void BindPointLoop(){
		if (bindPoint != null) {
			bindPointScript = bindPoint.GetComponent<TrackPoint>();
			if(bindPointScript!=null){
				//check if update is needed
				updatePoint = false;
				if(transform.position!=checkPosition){
					updatePoint = true;
				}
				if(!updatePoint){
					if(transform.rotation!=checkRotation){
						updatePoint = true;
					}
				}
				if(!updatePoint){
					if(width!=checkWidth){
						updatePoint = true;
					}
				}

	            if (!updatePoint){
	                if (height != checkHeight)
	                {
	                    updatePoint = true;
	                }
	            }
				//update points
				if(updatePoint){
					UpdateCheckPoint(this,true);
					bindPointScript.UpdateCheckPoint(this,false);
				}
			}
		}
	}

	public void UpdateCheckPoint(TrackPoint pointToClone,bool selfCall){

		checkPosition = pointToClone.transform.position;
		checkRotation = pointToClone.transform.localRotation;
        checkWidth = pointToClone.width;
        checkHeight = pointToClone.height;
		if (!selfCall) {
			Quaternion rot = pointToClone.transform.rotation;
			rot.x = -pointToClone.transform.rotation.x;
			rot.y = -pointToClone.transform.rotation.y;
			rot.z = -pointToClone.transform.rotation.z;
			rot.w = -pointToClone.transform.rotation.w;
			checkRotation = rot;
		} else {
			checkRotation = pointToClone.transform.rotation;
		}
		
		transform.position = checkPosition;
		transform.rotation = checkRotation;
        width = checkWidth;
        height = checkHeight;
	}
}