using UnityEngine;
using UnityEngine.UI;

enum Review
{
    Minus,
    Zero,
    VeryPoor,
    Poor,
    Average,
    Good,
    VeryGood,
    Great,
    Excellent,
    Awesome
}

public class ResultReview : MonoBehaviour
{
    [SerializeField] Text _resultText;
    Review _review;
    // Update is called once per frame
    void Update()
    {
        switch (_review)
        {
            case Review.Minus:
                //_resultText.text = "もう評価しないからね～|ω-｀)=3";
                break;
            case Review.Zero:
                //_resultText.text = "おまえの苦労をずっと見てたぞ(゜ =･∞･=　゜)";
                break;
            case Review.VeryPoor:
                //_resultText.text = "ここから入れる保険があるんですか?((((；ﾟДﾟ))))";
                break;
            case Review.Poor:
                //_resultText.text = "もっと、熱くなれよ!(ง ･̀ o･́)ง";
                break;
            case Review.Average:
                //_resultText.text = "いいスコアだ…(。-`ω´-)─┛~~";
                break;
            case Review.Good:
                //_resultText.text = "vanitas_vanitatum_et_omnia_vanitas(ᓀ‸ᓂ)";
                break;
            case Review.VeryGood:
                //_resultText.text = "プレイヤー半端ないって!_( ´ω`)";
                break;
            case Review.Great:
                //_resultText.text = "ﾄﾞｩﾜｧ!ﾛｸｾﾝｶﾗﾅﾅｾﾝ!!(ﾟ∀ﾟ)";
                break;
            case Review.Excellent:
                //_resultText.text = "誰もお前を貶さない＼( 'ω')／";
                break;
            case Review.Awesome:
                //_resultText.text = "もう、ここで終わってもいい…!щ(ﾟдﾟщ)";
                break;
        }
    }
    public void MinusReview() { _review = Review.Minus; }
    public void ZeroReview() { _review = Review.Zero; }
    public void VeryPoorReview() { _review = Review.VeryPoor; }
    public void PoorReview() { _review = Review.Poor; }
    public void AverageReview() { _review = Review.Average; }
    public void GoodReview() { _review = Review.Good; }
    public void VeryGoodReview() { _review = Review.VeryGood; }
    public void GreatReview() { _review = Review.Great; }
    public void ExcellentReview() { _review = Review.Excellent; }
    public void AwesomeReview() { _review = Review.Awesome; }
}
