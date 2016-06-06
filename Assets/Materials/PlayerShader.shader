Shader "Unlit/SingleColor"
{
    Properties
    {
        // Color property for material inspector, default to white
        _Color ("Main Color", Color) = (1,1,1,1)

        _RimCol ("Rim Colour" , Color) = (1,0,0,1)
        _RimPow ("Rim Power", Float) = 1.0
    }
    SubShader
    {
    	Pass {
            Name "Behind"
            Tags { "RenderType"="transparent" "Queue" = "Transparent" }
            Blend SrcAlpha OneMinusSrcAlpha
            ZTest Greater               // here the check is for the pixel being greater or closer to the camera, in which
            Cull Back                   // case the model is behind something, so this pass runs
            ZWrite Off
            LOD 200                    
           
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
           
            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : TEXCOORD1;      // Normal needed for rim lighting
                float3 viewDir : TEXCOORD2;     // as is view direction.
            };
           
            sampler2D _MainTex;
            float4 _RimCol;
            float _RimPow;
           
            float4 _MainTex_ST;
           
            v2f vert (appdata_tan v)
            {
                v2f o;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.normal = normalize(v.normal);
                o.viewDir = normalize(ObjSpaceViewDir(v.vertex));       //this could also be WorldSpaceViewDir, which would
                return o;                                               //return the World space view direction.
            }
           
            half4 frag (v2f i) : COLOR
            {
                half Rim = 1 - saturate(dot(normalize(i.viewDir), i.normal));       //Calculates where the model view falloff is       
                                                                                                                                   //for rim lighting.
               
                half4 RimOut = _RimCol * pow(Rim, _RimPow);
                return RimOut;
            }
            ENDCG
        }
        Pass
        {
        	Name "Regular"
            Tags { "RenderType"="Opaque" "LightMode" = "ForwardBase" }
            ZTest LEqual                // this checks for depth of the pixel being less than or equal to the shader
            ZWrite On                   // and if the depth is ok, it renders the main texture.
            Cull Back
            LOD 200

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            // color from the material
            uniform float4 _Color;
            uniform float4 _LightColor0;

            struct vertexInput{
            	float4 vertex : POSITION;
            	float3 normal : NORMAL;
            };

            struct vertexOutput{
            	float4 pos : SV_POSITION;
            	float4 col : COLOR;
            };

            vertexOutput vert (vertexInput v)
            {
            	vertexOutput o;

            	float3 normalDirection = normalize( mul(float4(v.normal, 0.0), _World2Object).xyz);

            	float3 lightDirection;
            	float atten = 1.0;

            	lightDirection = normalize( _WorldSpaceLightPos0.xyz );

            	float3 diffuseRefelection = atten * _LightColor0.xyz * _Color.rgb * max(0.0, dot(normalDirection, lightDirection));

            	o.col = float4(diffuseRefelection, 1.0);
            	o.pos = mul(UNITY_MATRIX_MVP , v.vertex);
                return o;
            }
            


            // pixel shader, no inputs needed
            float4 frag (vertexOutput i ) : COLOR
            {
                return i.col; // just return it
            }
            ENDCG
        }
    }
    Fallback "Diffuse"
}