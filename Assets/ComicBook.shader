Shader "LX/ComicBook"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }

    CGINCLUDE
    #include "UnityCG.cginc"

    sampler2D _MainTex;
    float _StripCosAngle;
    float _StripSinAngle;
    float _StripLimitsMin;
    float _StripLimitsMax;
    half3 _StripInnerColor;
    half3 _StripOuterColor;

    half3 _FillColor;
    half3 _BackgroundColor;

    float _StripDensity;
    float _StripThickness;
    half _Amount;


    struct v2f
    {
        float4 vertex : SV_POSITION;
        float2 uv : TEXCOORD0;
    };

    half3 strip_color(half2 uv)
    {

        fixed passStep = step(_StripThickness,
                              (cos(dot(uv * _StripDensity, float2(_StripCosAngle, _StripSinAngle))) + 1) / 2);
        return lerp(_StripInnerColor, _StripOuterColor, passStep);
    }


    v2f vert(appdata_base v)
    {
        v2f o;
        o.vertex = UnityObjectToClipPos(v.vertex);
        return o;
    }

    half4 frag(v2f_img i) : SV_Target
    {

        half lum = Luminance(tex2D(_MainTex, i.uv).rgb);
        half underMin = step(lum, _StripLimitsMin);
        half betweenLimit = step(_StripLimitsMin, lum) * step(lum, _StripLimitsMax);

        half3 color = lerp(lerp(_BackgroundColor, strip_color(i.uv), betweenLimit), _FillColor, underMin);


        half3 oldColor = tex2D(_MainTex, i.uv).rgb;
        return half4(lerp(oldColor, color, _Amount), 1.0);
    }
    ENDCG

    SubShader
    {
        ZTest Always Cull Off ZWrite Off
        Fog
        {
            Mode off
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            ENDCG
        }
    }
    FallBack off
}
