using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Digoel.Common
{
    public static class Source
    {
        public static string Text { get; set; } = @"car/dog/run/half/cool/hag/egg/monster/moon/star/phone/chair/red/orange/blue/purple/cloudy/sunny/rainy/boom/explosion/program/grass/tree/snow/mountain/circle/square/triangle/can/coffee/tea/clubbing/corgi/shiba/hamster/raccoon/money/card/plastic/metal/screen/national/culture/wrapping/christmas/easter/key/door/wall/picture/spotted/teacher/student/city/town/village/drink/eat/base/combat/tank/armed/arms/leg/head/feet";


        internal static IEnumerable<string> Rearrange(string words)
        {
            return words.Split("/").OrderBy(x => RandomHelper.Instance.Next());
        }

        internal static IEnumerable<string> WordList(bool includePuncation)
        {
            return includePuncation ? Rearrange(Text) : Rearrange(Text.Remove(","));
        }

        public static void Update(string text)
        {
            Text = text;
        }
    }
}