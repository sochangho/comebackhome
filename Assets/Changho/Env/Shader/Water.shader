Shader "Custom/Water"
{
    Properties
    {
        _Bumpmap("NomalMap" , 2D) = "bump" {}
        _Cube("Cube", Cube) = ""{}
        _SPColor("Specular Color",color) = (1,1,1)
        _SPPower("Specular Power", Range(50,300)) = 150
        _SPMulti("Specular Multiply", Range(1,10)) = 3
        _WaveH("Wave Height", Range(0,10)) = 0.1
        _WaveL("Wave Length", Range(5, 20)) = 12
        _WaveT("Wave Timing", Range(0,10)) = 1
       
    }
        SubShader
    {
        Tags {"RendererType" = "Transparent" "Queue" = "Transparent" }

        


        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf WaterSpecular alpha:fade 

        samplerCUBE _Cube;
        sampler2D _Bumpmap;
        float4 _SPColor;
        float _SPPower;
        float _SPMulti;
        float _WaveH;
        float _WaveL;
        float _WaveT;
       

     /*   void vert(inout appdata_full v) {

            float movement;
            movement = sin(abs((v.texcoord.x * 2 - 1) * _WaveL) + _Time.y * _WaveT) * _WaveH;
            movement = sin(abs((v.texcoord.y * 2 - 1) * _WaveL) + _Time.y * _WaveT) * _WaveH;

            v.vertex.y += movement / 2;


        }*/


        struct Input
        {
            float2 uv_Bumpmap;
            float3 worldRefl;
            float3 viewDir;
            
            INTERNAL_DATA
        };

      

      
        void surf (Input IN, inout SurfaceOutput o)
        {
            float3 normal1 = UnpackNormal(tex2D(_Bumpmap, IN.uv_Bumpmap + _Time.x * 0.1));
            float3 normal2 = UnpackNormal(tex2D(_Bumpmap, IN.uv_Bumpmap - _Time.x * 0.1));
             
            o.Normal =( normal1 + normal2 )/2;
            float3 refcolor = texCUBE(_Cube, WorldReflectionVector(IN, o.Normal));


            float rim = saturate(dot(o.Normal, IN.viewDir));
            rim = pow(1 - rim, 1.5);


            o.Emission = (refcolor * rim); //* reflaction);// * 0.5 ;
            o.Alpha = saturate(rim + 0.5);
           
        }

        float4 LightingWaterSpecular(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten) 
        {
            float3 H = normalize(lightDir + viewDir);
            float spec = saturate(dot(H, s.Normal));
            spec = pow(spec, _SPPower);

            float4 finalColor;
            finalColor.rgb = spec * _SPColor.rgb * _SPMulti;
            finalColor.a = s.Alpha+ spec ;

            return finalColor;


        }


        ENDCG
    }
    FallBack "Legacy Shaders/Transparent/Vertexlit"
}
