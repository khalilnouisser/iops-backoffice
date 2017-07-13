
<?php header('Access-Control-Allow-Origin: *'); ?>
<div class="section back-black" id="subscription">

        <div class="twelve columns">
            <div class="title-text-main">
                <br><br><br>
                <h1>Subscribe</h1>
            </div>
        </div>
        <div class="section padding-bottom">
            <div class="container">
                <form name="ajax-form" id="ajax-form" action=""
                      method="post">

                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="fname">
                            <span class="error" id="err-name">please enter first name</span>
                        </label>
                        <input name="fname" id="fname" type="text" placeholder="Your First Name :*"/>
                    </div>

                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="lname">
                            <span class="error" id="err-name">please enter last name</span>
                        </label>
                        <input name="lname" id="lname" type="text" placeholder="Your Last Name :*"/>
                    </div>

                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="uname">
                            <span class="error" id="err-name">please enter username</span>
                        </label>
                        <input name="uname" id="uname" type="text" placeholder="Username :*"/>
                    </div>

                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="email">
                            <span class="error" id="err-name">please enter valid email</span>
                        </label>
                        <input name="email" id="email" type="email" placeholder="Email :*"/>
                    </div>

                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="email">
                            <span class="error" id="err-name">please enter a valid password (+8 characters)</span>
                        </label>
                        <input name="password1" id="password1" type="password" placeholder="Password (+8 characters)"/>
                    </div>

                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="email">
                            <span class="error" id="err-name">passwords don't match</span>
                        </label>
                        <input name="password2" id="password2" type="password" placeholder="Retype your password"/>
                    </div>

                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="birthday">
                            <span class="error" id="err-name">your date is invalids</span>
                        </label>
                        <input name="birthday" id="birthday" type="date" placeholder="Birthday"/>
                    </div>

                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="institut">
                            <span class="error" id="err-name">please enter a valid institution name</span>
                        </label>
                        <input name="institut" id="institut" type="text" placeholder="Where are you studying ?"/>
                    </div>
                    <br>
                    <br>

                    <div class="six columns picture-upload" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="pic">
                            <span class="error" id="err-name">your date is invalids</span>
                        </label>
                        <span>Please upload a proof of identity<br>(student card)</span>
                        <input name="pic" id="pic" type="file" placeholder=""/>
                    </div>

                    <div class="six columns recaptcha" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <div class="g-recaptcha" data-sitekey="6LdK3ygUAAAAAOYNxVJvi736VhQmklLC4jtnFSxG"></div>
                    </div>

                    <div class="twelve columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <div id="button-con">
                            <button class="send_message button-effect button--moema button--text-thick button--text-upper button--size-s"
                                    id="send-subscription">Subscribe
                            </button>
                        </div>
                    </div>
                    <div class="clear"></div>
                    <div class="error text-align-center" id="err-form">There was a problem validating the form please
                        check!
                    </div>
                    <div class="error text-align-center" id="err-timedout">The connection to the server timed out!</div>
                    <div class="error" id="err-state"></div>
                </form>

                <div class="clear"></div>
                <div id="ajaxsuccess">Successfully sent!!</div>
                <div class="clear"></div>
            </div>
        </div>


</div>