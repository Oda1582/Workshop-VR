//Shady
Shader "Barely Visible"
{
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		MyLightDirection("Light Direction", Vector) = (0,0,1,0)
		MyLightPosition("Light Position", Vector) = (0,0,0,0)
		MyLightAngle("Light Angle", Range(0,180)) = 45
		MyStrengthScalor("Strength", Float) = 100
	}//Properties end
	SubShader
	{
		Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 200
		CGPROGRAM
		#pragma surface SurfaceReveal Standard fullforwardshadows alpha:fade
		#pragma target 3.0
		sampler2D _MainTex;

		struct Input
		{
			float2 uv_MainTex;
			float3 worldPos;
		};//Struct end

		half   _Glossiness;
		half   _Metallic;
		fixed4 _Color;
		float4 MyLightPosition;
		float4 MyLightDirection;
		float  MyLightAngle;
		float  MyStrengthScalor;

		void SurfaceReveal(Input input, inout SurfaceOutputStandard R)
		{ 
			float3 Dir      = normalize(MyLightPosition - input.worldPos);
			float  Scale    = dot(Dir, MyLightDirection);
			float  Strength = Scale - cos(MyLightAngle * (3.14 / 360.0));
			Strength        = min(max(Strength * MyStrengthScalor, 0), 1);
			fixed4 RC       = tex2D(_MainTex, input.uv_MainTex) * _Color;
			R.Albedo        = RC.rgb;
			// R.Emission      = RC.rgb * RC.a * Strength;
			R.Metallic      = _Metallic;
			R.Smoothness    = _Glossiness;
			R.Alpha         = 0.3;
		}//SurfaceReveal end
	ENDCG
	}//SubShader end
		FallBack "Diffuse"
}//Shader end