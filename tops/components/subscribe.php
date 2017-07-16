
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
                      method="post" enctype="multipart/form-data">
                <input type="hidden" name="CountryID" value="tn"/>
                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="fname">
                            <span class="error" id="err-fname">please enter first name</span>
                        </label>
                        <input name="Fname" id="fname" type="text" placeholder="Your First Name :*" required/>
                    </div>

                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="lname">
                            <span class="error" id="err-lname">please enter last name</span>
                        </label>
                        <input name="Lname" id="lname" type="text" placeholder="Your Last Name :*" required/>
                    </div>

                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="uname">
                            <span class="error" id="err-uname">please enter username</span>
                        </label>
                        <input name="Username" id="uname" type="text" placeholder="Username :*" required/>
                    </div>

                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="email">
                            <span class="error" id="err-email">please enter valid email</span>
                        </label>
                        <input name="EmailAdress" id="email" type="email" placeholder="Email :*" required/>
                    </div>
<!--
                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="email">
                            <span class="error" id="err-password1">please enter a valid password (+8 characters)</span>
                        </label>
                        <input name="Password1" id="password1" type="password" placeholder="Password (+8 characters)" required/>
                    </div>

                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="email">
                            <span class="error" id="err-password2">passwords don't match</span>
                        </label>
                        <input name="Password2" id="password2" type="password" placeholder="Retype your password" required/>
                    </div>
-->
                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="birthday">
                            <span class="error" id="err-birthday">your date is invalid</span>
                        </label>
                        <input name="BirthdayDate" id="birthday" type="date" placeholder="Birthday" required/>
                    </div>

                    <div class="six columns" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="institut">
                            <span class="error" id="err-institut">please enter a valid institution name</span>
                        </label>
                        <input name="University" id="institut" type="text" placeholder="Where are you studying ?" required/>
                    </div>
                    <br>
                    <br>

                    <div class="six columns picture-upload" data-scroll-reveal="enter bottom move 100px over 1s after 0.5s">
                        <label for="pic">
                            <span class="error" id="err-pic">your file is invalid</span>
                        </label>
                        <span>Please upload a proof of identity<br>(student card) [max 8MB]</span>
                        <input name="file" id="pic" type="file" placeholder="" accept="image/*" required/>
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